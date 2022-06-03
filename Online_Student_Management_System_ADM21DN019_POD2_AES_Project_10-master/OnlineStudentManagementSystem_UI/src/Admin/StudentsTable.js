import React, { useState, useEffect } from 'react'; 
import axios from 'axios'; 
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap'; 
function StudentTable(props) { 
    const [data, setData] = useState([]); 
 
    useEffect(() => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Students'); 
            setData(result.data); 
        } 
        GetData(); 
    } 
        , []); 
 
    const DeleteStudent = (studentId) => { 
        axios.delete('https://localhost:44384/api/Students/'+studentId) 
            .then((result) => { 
                const GetData = async () => { 
                    const result = await axios.get('https://localhost:44384/api/Students'); 
                    setData(result.data); 
                } 
                GetData(); 
            }) 
            .catch((error) => { 
                alert(error); 
            }); 
             
    } 
    const GetStudent = (studentId) => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Students/'+studentId); 
            var resultarray=[]; 
            resultarray.push(result.data); 
 
            setData(resultarray); 
            console.log(result.data) 
        } 
        GetData(); 
    } 
    const[book, setBook] = useState({studentId:''}); 
    const onChange =(e)=>{ 
        e.persist(); 
        setBook({...book,[e.target.name]:e.target.value}); 
      } 
      const UpdateStudent=(e)=>{ 
         
        const data = { 
          studentId : props.match.params.studentId, 
          studentName: book.studentName, 
          dob: book.dob, 
          addressCodeId:book.addressCodeId
          
        }; 
        const url = 'https://localhost:44384/api/Students/'+data.studentId; 
        axios.put(url,data) 
        .then((result)=>{ 
          props.history.push('/Students') 
        }); 
      } 
   
          
return ( 
    <div className="animated fadeIn"> 
    <br></br>
        <Row> 
            <Col> 
                <Card> 
                    <CardHeader> 
 
                        <i className="fa fa-align-justify"></i>Students 
                    </CardHeader> 
                    <CardBody> 
                        <div> 
                            <input type="text" name="studentId" onChange={onChange} value={book.studentId} className="form-control ml-2"placeholder='ID'/> 
                             
                            <div className='input-group-append'> 
                                <button onClick={() => GetStudent(book.studentId)} className='btn btn-sm btn-primary' >Get By Id</button> 
                            </div> 
                        </div> 
                        <Table hover bordered striped responsive size="sm"> 
                            <thead> 
                                <tr> 
                                    <th>StudentId</th> 
                                    <th>StudentName</th> 
                                    <th>DOB</th> 
                                    <th>CourseId</th>
                                    <th>AddressCodeId</th>
                                    <th>CoursName</th>
                                   
                                    <th>City</th>
                                    <th>State</th>
                                    
                                    
                                </tr> 
                            </thead> 
                            <tbody> 
                                { 
                                     data.map((item, idx) => { 
                                        return <tr key={idx}> 
                                            <td>{item.studentId}</td> 
                                            <td>{item.studentName}</td> 
                                            <td>{item.dob}</td> 
                                            <td>{item.courseId}</td> 
                                            <td>{item.addressCodeId}</td> 
                                            <td>{item.course.courseName}</td> 
                                            
                                            <td>{item.addressCode.city}</td> 
                                            <td>{item.addressCode.state}</td> 
                                           
                                          
                                          
                                            <td> 
                                                <div className="btn-group"> 
                                                <button className="btn btn-warning" onClick={() => UpdateStudent(item.StudentId)}>Update</button> 
 
                                                    <button className="btnbtn-warning" onClick={() => DeleteStudent(item.studentId)}>Delete</button> 
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
 
 
export default StudentTable;