import React, { useState, useEffect } from 'react'; 
import axios from 'axios'; 
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap'; 
 
function Subjects(props) { 
    const [data, setData] = useState([]); 
 
    useEffect(() => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Subjects/'); 
            setData(result.data); 
        } 
        GetData(); 
    } 
        , []); 
 
    const DeleteSubject = (subjectId) => { 
        axios.delete('https://localhost:44384/api/Subjects/'+subjectId) 
            .then((result) => { 
                const GetData = async () => { 
                    const result = await axios.get('https://localhost:44384/api/Subjects/'); 
                    setData(result.data); 
                } 
                GetData(); 
            }) 
            .catch((error) => { 
                alert(error); 
            }); 
             
    } 
    const GetSubject = (subjectId) => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Subjects/'+subjectId); 
            var resultarray=[]; 
            resultarray.push(result.data); 
 
            setData(resultarray); 
            console.log(result.data) 
        } 
        GetData(); 
    } 
    const[book, setBook] = useState({subjectId:''}); 
    const onChange =(e)=>{ 
        e.persist(); 
        setBook({...book,[e.target.name]:e.target.value}); 
      } 
      const UpdateSubject=(e)=>{ 
         
        const data = { 
          subjectId : props.match.params.subjectId, 
          subjectName: book.subjectName
          
        }; 
        const url = 'https://localhost:44384/api/Subjects/'+data.subjectId; 
        axios.put(url,data) 
        .then((result)=>{ 
          props.history.push('/Subjects') 
        }); 
      } 
   
          
return ( 
    <div className="animated fadeIn"> 
    <br></br>
        <Row> 
            <Col> 
                <Card> 
                    <CardHeader> 
 
                        <i className="fa fa-align-justify"></i> Subjects
                    </CardHeader> 
                    <CardBody> 
                        <div> 
                            <input type="text" name="subjectId" onChange={onChange} value={book.subjectId} className="form-control ml-2"placeholder='ID'/> 
                             
                            <div className='input-group-append'> 
                                <button onClick={() => GetSubject(book.subjectId)} className='btn btn-sm btn-primary' >Get By Id</button> 
                            </div> 
                        </div> 
                        <Table hover bordered striped responsive size="sm"> 
                            <thead> 
                                <tr> 
                                    <th>SubjectId</th> 
                                    <th>SubjectName</th> 
                                  
                                </tr> 
                            </thead> 
                            <tbody> 
                                { 
                                     data.map((item, idx) => { 
                                        return <tr key={idx}> 
                                            <td>{item.subjectId}</td> 
                                            <td>{item.subjectName}</td> 
                                             
                                            <td> 
                                                <div className="btn-group"> 
                                                <button className="btn btn-warning" onClick={() => UpdateSubject(item.subjectId)}>Update</button> 
 
                                                    <button className="btnbtn-warning" onClick={() => DeleteSubject(item.subjectId)}>Delete</button> 
                                                </div> 
                                            </td> 
                                        </tr> 
                                    })} 
                            </tbody> 
                        </Table> 
 
 
                    </CardBody> 
                </Card> 
            </Col> 
        </Row> 
    </div> 
) 
} 
 
 
export default Subjects;