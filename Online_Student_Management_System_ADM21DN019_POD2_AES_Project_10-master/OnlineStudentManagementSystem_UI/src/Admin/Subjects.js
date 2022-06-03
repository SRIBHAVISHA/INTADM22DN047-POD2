import React, { Component } from 'react'
import axios from 'axios'
import { Link } from "react-router-dom";
import {Card, CardBody, CardHeader, Col, Row, Table} from 'reactstrap';

   
export class CreateSubject extends Component {
	constructor(props) {
		super(props)

		this.state = {
           
           subjectName: ''

			
		}
	}

	changeHandler = e => {
		this.setState({ [e.target.name]: e.target.value })
	}

	submitHandler = e => {
		e.preventDefault()
		console.log(this.state)
		axios
			.post('https://localhost:44384/api/Subjects', this.state)
			.then(response => {
				console.log(response)
			})
			.catch(error => {
				console.log(error)
			})
	}

	render() {
		const { subjectName } = this.state
		return (
			
			<div class="main-block">
				<br></br>
        <h2 style={{color: "black"}}>Add Subject</h2>

			<div>
            <div>
				<form onSubmit={this.submitHandler}>
					<div>
                    <lable className="txt" style={{color: "Black"}}>Enter Subject name:  </lable>
						<input
							type="text"
							placeholder='Enter Subject Name'
							name="subjectName"
							required={true}
							value={subjectName}
							onChange={this.changeHandler}
						/>
					</div>

                    <br></br>

					<br></br>

					<button className='buttons' style={{backgroundColor:'black'}} type="submit">Submit</button>&nbsp;
					

					
					<button className='buttons' style={{backgroundColor:'black'}}>
					<Link to="SubjectTable" className="formFieldLink">

					<a href="/SubjectTable">View</a></Link>
					</button>

				</form>
                </div>
			</div>
			</div>
		)
	}
}

export default CreateSubject;
