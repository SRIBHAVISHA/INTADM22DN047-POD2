import React, { Component } from 'react'
import axios from 'axios'
import { Link } from "react-router-dom";
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap';


export class CreateStudent extends Component {
	constructor(props) {
		super(props)

		this.state = {
			studentName: '',
			dob: '',
			state:'',
			addressCode: {
				city: '',
				state2: '',
				zipCode: ''
			},
			course: {
				courseName: ''
			}
		}
	}

	changeHandler = e => {
		this.setState({ [e.target.name]: e.target.value })
	}

	submitHandler = e => {
		e.preventDefault()
		console.log(this.state)
		axios
			//.post('https://localhost:44384/api/Students', this.state)
			.post('https://localhost:44384/api/Students',
			{
				studentName: this.state.studentName,
				dob:this.state.dob,
				courseId:this.state.courseId,
				addressCodeId:this.state.addressCodeId

				// addressCode: {
				// city: this.state.city,
				// state: this.state.state,
				// zipCode:this.state.zipCode
				// },
				// course:{
				// courseName:this.state.courseName
				// }
			})

			.then(response => {


				console.log(response)
			})
			.catch(error => {
				console.log(error)
			})
	}

	render() {
		console.log(this.state);
		//const { studentName, dob,addressCode, courseName } = this.state;
		//const { studentName, dob, city, state, zipCode, courseName } = this.state
		//const { studentName, dob, AddressCodeId, courseId , addressCode, course} = this.state
		const { studentName, dob, addressCodeId, courseId , addressCode, course} = this.state


		

		return (

   <style>
        body
        {
            background-image:url('https://techtrosite.files.wordpress.com/2016/08/photo-1438301763357-e0c3309fe59d.jpeg?w=900');
            background-size:cover;
            background-repeat: no-repeat;
            text-align: center;
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
				<h2 style={{ color: "blue" }}> Add Student</h2>

				<div>
					<form onSubmit={this.submitHandler}>
						<div>

							<lable className="txt" style={{ color: "Blue" }}>Enter Students Name:  </lable>
							<input
								type="text"
								placeholder='Enter Student Name'
								name="studentName"
								required={true}
								value={studentName}
								onChange={this.changeHandler}
							/>
						</div>
						<br></br>

						<div>
							<lable className="txt" style={{ color: "Blue" }}>Enter Date of Birth:  </lable>
							<input
								type="date"
								placeholder='Enter Date Of Birth'
								name="dob"
								required={true}
								value={dob}
								onChange={this.changeHandler}
							/>
						</div>
						<br></br>
						<div>
							<lable className="txt" style={{ color: "Blue" }}>Enter CourseId:  </lable>
							<input
								placeholder="Enter CourseId"
								type="number"
								name="courseId"
								value={courseId}
								onChange={this.changeHandler}
								required={true}
							/>
						</div>
						<br></br>
						<div>
							<lable className="txt" style={{ color: "Blue" }}>Enter AddressCodeId:  </lable>
							<input
								type="number"
								placeholder='Enter AddressCodeId'
								name="addressCodeId"
								value={addressCodeId}
								onChange={this.changeHandler}
							/>
						</div>
						<br></br>
						 <div>
							<lable className="txt" style={{ color: "Blue" }}>Enter Zip Code:  </lable>
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
							<lable className="txt" style={{ color: "Blue" }}>Enter Course:  </lable>
							<input
								type="text"
								placeholder='Enter Course Name'
								name="courseName"
								value={courseName}
								onChange={this.changeHandler}
							/>

						</div> 
						<br></br>
						<br></br>
						<button class='buttons' style={{ backgroundColor: 'blue' }} type="submit">Submit</button>&nbsp;


						<button class='buttons' style={{ backgroundColor: 'blue' }}>
							<Link to="StudentsTable" className="formFieldLink">

								<a href="/StudentsTable" style="color:white">View</a></Link>
						</button>



					</form>
				</div>
			</div>
</body>
		)
	}
}

export default CreateStudent;
