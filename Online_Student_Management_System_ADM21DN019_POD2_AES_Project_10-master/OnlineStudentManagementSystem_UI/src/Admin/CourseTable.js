import React, { useState, useEffect } from 'react'; 
import axios from 'axios'; 
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap'; 
 
function CourseTable(props) { 
    const [data, setData] = useState([]); 
 
    useEffect(() => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Courses/'); 
            setData(result.data); 
        } 
        GetData(); 
    } 
        , []); 
 
    const DeleteCourses = (courseId) => { 
        axios.delete('https://localhost:44384/api/Courses/'+courseId) 
            .then((result) => { 
                const GetData = async () => { 
                    const result = await axios.get('https://localhost:44384/api/Courses/'); 
                    setData(result.data); 
                } 
                GetData(); 
            }) 
            .catch((error) => { 
                alert(error); 
            }); 
             
    } 
    const GetCourse = (courseId) => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/Courses/'+courseId); 
            var resultarray=[]; 
            resultarray.push(result.data); 
 
            setData(resultarray); 
            console.log(result.data) 
        } 
        GetData(); 
    } 
    const[book, setBook] = useState({courseId:''}); 
    const onChange =(e)=>{ 
        e.persist(); 
        setBook({...book,[e.target.name]:e.target.value}); 
      } 
      const UpdateCourse=(e)=>{ 
         
        const data = { 
          courseId : props.match.params.courseId, 
          courseName: book.courseName
          
        }; 
        const url = 'https://localhost:44384/api/Courses/'+data.courseId; 
        axios.put(url,data) 
        .then((result)=>{ 
          props.history.push('/Courses') 
        }); 
      } 
   
          
return ( 
    <style>
        body
        {
            background-image:url('https://png.pngtree.com/thumb_back/fh260/back_our/20190621/ourmid/pngtree-teachers--classroom-counseling-training-course-poster-image_188622.jpg');
            background-size:cover;
            background-repeat: no-repeat;
            text-align: center;
        }
        
    </style>
<body>
<div className="animated fadeIn"> 
    <br></br>
        <Row> 
            <Col> 
                <Card> 
                    <CardHeader> 
 
                        <i className="fa fa-align-justify"></i> Courses
                    </CardHeader> 
                    <CardBody> 
                        <div> 
                            <input type="text" name="courseId" onChange={onChange} value={book.courseId} className="form-control ml-2"placeholder='Course ID'/> 
                             
                            <div className='input-group-append'> 
                                <button onClick={() => GetCourse(book.courseId)} className='btn btn-sm btn-primary' >Get By Id</button> 
                            </div> 
                        </div> 
                        <Table hover bordered striped responsive size="sm"> 
                            <thead> 
                                <tr> 
                                    <th>CourseId</th> 
                                    <th>Course</th> 
                                  
                                </tr> 
                            </thead> 
                            <tbody> 
                                { 
                                     data.map((item, idx) => { 
                                        return <tr key={idx}> 
                                            <td>{item.courseId}</td> 
                                            <td>{item.courseName}</td> 
                                             
                                            <td> 
                                                <div className="btn-group"> 
                                                <button className="btn btn-warning" onClick={() => UpdateCourse(item.courseId)}>Update</button> 
 
                                                    <button className="btn
btn-warning" onClick={() => DeleteCourses(item.courseId)}>Delete</button> 
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
</body>
) 
} 
 
 
export default CourseTable;