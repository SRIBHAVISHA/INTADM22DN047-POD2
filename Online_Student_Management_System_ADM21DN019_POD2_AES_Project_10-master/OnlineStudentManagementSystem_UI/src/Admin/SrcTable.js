import React, { useState, useEffect } from 'react';  
import axios from 'axios';  
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';  
  
function SrcTable(props) {  
    const [data, setData] = useState([]);  
  
    useEffect(() => {  
        const GetData = async () => {  
            const result = await axios.get('https://localhost:44384/api/SubjectReportCards/');  
            setData(result.data);  
        }  
        GetData();  
    }  
        , []);  
  
        const DeleteSubjectReportCard = (subjectReportCardId) => {  
            axios.delete('https://localhost:44384/api/SubjectReportCards/'+subjectReportCardId)  
                .then((result) => {  
                    const GetData = async () => {  
                        const result = await axios.get('https://localhost:44384/api/SubjectReportCards');  
                        setData(result.data);  
                    }  
                    GetData();  
                })  
                .catch((error) => {  
                    alert(error);  
                });  
                  
        }
     
    const GetSubjectReportCard = (subjectReportCardId) => {  
        const GetData = async () => {  
            const result = await axios.get('https://localhost:44384/api/SubjectReportCards/'+subjectReportCardId);  
            var resultarray=[];  
            resultarray.push(result.data);  
  
            setData(resultarray);  
            console.log(result.data)  
        }  
        GetData();  
    }  
    const[book, setBook] = useState({subjectReportCardId:''});  
    const onChange =(e)=>{  
        e.persist();  
        setBook({...book,[e.target.name]:e.target.value});  
      }  
      const UpdateSubjectReportCard=(e)=>{  
          
        const data = {  
          subjectReportCardId : props.match.params.subjectReportCardId,  
          studentId: book.studentId,  
          subjectId: book.subjectId,  
          marks:book.marks  
        };  
        const url = 'https://localhost:44384/api/SubjectReportCards/'+data.subjectReportCardId;  
        axios.put(url,data)  
        .then((result)=>{  
          props.history.push('/SubjectReportCards')  
        });  
      }  
    
           
return (  
    <div className="animated fadeIn">  
    <br></br> 
        <Row>  
            <Col>  
                <Card>  
                    <CardHeader>  
  
                        <i className="fa fa-align-justify"></i> SubjectReportCards  
                    </CardHeader>  
                    <CardBody>  
                        <div>  
                            <input type="text" name="subjectReportCardId" onChange={onChange} value={book.subjectReportCardId} className="form-control ml-2"placeholder='ID'/>  
                              
                            <div className='input-group-append'>  
                                <button onClick={() => GetSubjectReportCard(book.subjectReportCardId)} className='btn btn-sm btn-primary' >Get By Id</button>  
                            </div>  
                        </div>  
                        <Table hover bordered striped responsive size="sm">  
                            <thead>  
                                <tr>  
                                    <th>SubjectReportCardId</th>
                                    <th>Marks</th>  
                                    <th>SubjectId</th>  
                                    <th>StudentId</th>  
                                    <th>SubjectName</th>  
                                    <th>StudentName</th> 
                                    
                                </tr>  
                            </thead>  
                            <tbody>  
                                {  
                                     data.map((item, idx) => {  
                                        return <tr key={idx}>  
                                            <td>{item.subjectReportCardId}</td>  
                                            <td>{item.marks}</td>
                                            <td>{item.subjectId}</td>  
                                            <td>{item.studentId}</td> 
                                            <td>{item.subject.subjectName}</td> 
                                            <td>{item.student.studentName}</td> 
                                         
                                             
                                            <td>  
                                                <div className="btn-group">  
                                                <button className="btn btn-warning" onClick={() => UpdateSubjectReportCard(item.addressCodeId)}>Update</button>  
  
                                              <button className="btnbtn-warning" onClick={() => DeleteSubjectReportCard(item.subjectReportCardId)}>Delete</button>
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
  
  
export default SrcTable;

