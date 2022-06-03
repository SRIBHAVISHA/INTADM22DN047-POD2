import React, { Component } from 'react' 
import axios from 'axios' 
import { Link } from "react-router-dom"; 
import {Card, CardBody, CardHeader, Col, Row, Table} from 'reactstrap'; 
 
    
class CreateSujectReportCard extends Component { 
 constructor(props) { 
  super(props) 
 
  this.state = { 
    
	
	
	subjectId: '',
	studentId: '',
	marks: ''
	  
 } 
}
 changeHandler = e => { 
  this.setState({ [e.target.name]: e.target.value }) 
 } 
 
 submitHandler = e => { 
  e.preventDefault() 
  console.log(this.state) 
  const result=axios.post('https://localhost:44384/api/SubjectReportCards', this.state) 
   .then(response => { 
    console.log(response) 
    var resultarray=[];  
            resultarray.push(result.data);  
 
   }) 
   .catch(error => { 
    console.log(error) 
   }) 
 } 
 
 render() { 
  const { marks,studentId,subjectId,subject,student } = this.state 
  return ( 
    
   <div class="main-block"> 
    <br></br> 
        <h2 style={{color: "black"}}>Add SubjectReportCard</h2> 
 
   <div> 
            <div> 
    <form onSubmit={this.submitHandler}> 
     <div> 
     <lable className="txt" style={{color: "Black"}}>Enter Student Marks:  </lable> 
      <input 
       type="text" 
       placeholder='Enter Marks' 
       name="marks" 
       required={true} 
       value={marks} 
       onChange={this.changeHandler} 
      /> 
     </div> 
     <br></br> 
                    <div> 
     <div> 
     <lable className="txt" style={{color: "Black"}}>Enter StudentId:  </lable> 
      <input 
       type="number" 
       placeholder='studentId' 
       name="studentId" 
       required={true} 
       value={studentId} 
       onChange={this.changeHandler} 
      /> 
     </div> 
     <br></br> 
                     
                    <div> 
                    <lable className="txt" style={{color: "Black"}}>Enter SubjectId:  </lable> 
      <input 
       type="number" 
       placeholder='Enter SubjectId' 
       name="subjectId" 
       required={true} 
       value={subjectId} 
       onChange={this.changeHandler} 
      /> 
     </div>    
                    <br></br> 
     </div>    
{/*                     
                    <div> 
                    <lable className="txt" style={{color: "Black"}}>Enter City:  </lable> 
      <input 
          placeholder="Enter City" 
       type="text" 
       name="city" 
       value={city} 
       onChange={this.changeHandler} 
       required={true} 
      /> 
     </div>  */}
                    {/* <br></br> 
     <div> 
                    <lable className="txt" style={{color: "Black"}}>Enter State:  </lable> 
      <input 
       type="text" 
       placeholder='Enter State' 
       name="state" 
       value={state} 
       onChange={this.changeHandler} 
      /> 
     </div> 
                    <br></br> 
                    <div> 
                    <lable className="txt" style={{color: "Black"}}>Enter Zip Code:  </lable> 
      <input 
       type="text" 
       placeholder='Enter Zip Code' 
       name="zipCode" 
       value={zipCode} 
       onChange={this.changeHandler} 
      /> 
 
     </div> 
                    <br></br> 
     <div> 
     <lable className="txt" style={{color: "Black"}}>Enter Course name:  </lable> 
      <input 
       type="text" 
       placeholder='Enter Course Name' 
       name="courseName" 
       required={true} 
       value={courseName} 
       onChange={this.changeHandler} 
      /> 
     </div>    
     <br></br> 
 
                    <div> 
     <lable className="txt" style={{color: "Black"}}>Enter Subject name:  </lable> 
      <input 
          placeholder="Enter Subject name" 
       type="text" 
       name="subjectName" 
       value={subjectName} 
       onChange={this.changeHandler} 
       required={true} 
      /> 
     </div>  */}
     <br></br> 
      
 
     <button className='buttons' style={{backgroundColor:'black'}}
type="submit">Submit</button>&nbsp; 
 
      
     <button className='buttons' style={{backgroundColor:'black'}}> 
     <Link to="SrcTable" className="formFieldLink"> 
 
     <a href="/SrcTable">View</a></Link> 
     </button> 
 
    </form> 
                </div> 
   </div> 
   </div> 
  ) 
 } 
} 
 
export default CreateSujectReportCard;