import React, { Component } from 'react'
import axios from 'axios'
import { Link } from "react-router-dom";
import {Card, CardBody, CardHeader, Col, Row, Table} from 'reactstrap';

   
export class CreateCourse extends Component {
	constructor(props) {
		super(props)

		this.state = {
           
           courseName: ''

			
		}
	}

	changeHandler = e => {
		this.setState({ [e.target.name]: e.target.value })
	}

	submitHandler = e => {
		e.preventDefault()
		console.log(this.state)
		axios
			.post('https://localhost:44384/api/Courses', this.state)
			.then(response => {
				console.log(response)
			})
			.catch(error => {
				console.log(error)
			})
	}

	render() {
		const { courseName } = this.state
		return (
			
			<style>
        body
        {
            background-image:url('https://png.pngtree.com/thumb_back/fw800/back_our/20190621/ourmid/pngtree-teacher-s-college-classroom-coaching-course-poster-background-image_188494.jpg');
            background-size:cover;
            background-repeat: no-repeat;
            text-align: left;
            color:blue;
            
        }
        .buttons
        {
            background-color: blue;
            color: white;
        }
        
    </style>
<body>
<div class="main-block">
				<br></br>
        <h2 style={{color: "blue"}}>Add Course</h2>

			<div>
			
            <div>
				<form onSubmit={this.submitHandler}>
					<div>
                    <lable className="txt" style={{color: "Blue"}}>Enter Course name: </lable>
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

					<br></br>

					<button class='buttons' style={{backgroundColor:'blue'}} type="submit">Submit</button>&nbsp;

					
					<button class='buttons' style={{backgroundColor:'blue'}} >
					<Link to="CourseTable" className="formFieldLink">

					<a href="/CourseTable" style="color:white">View</a></Link>
					</button>

				</form>
                </div>
			</div>
			</div>
</body>
		)
	}
}

export default CreateCourse;
