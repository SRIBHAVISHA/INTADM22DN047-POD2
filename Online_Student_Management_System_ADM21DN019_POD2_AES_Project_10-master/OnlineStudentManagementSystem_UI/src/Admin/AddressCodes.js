import React, { Component } from 'react'
import axios from 'axios'
import { Link } from "react-router-dom";
export class AddressCodes extends Component {
	constructor(props) {
		super(props)

		this.state = {
			city: '',
			state: '',
            zipCode:''
		}
	}

	changeHandler = e => {
		this.setState({ [e.target.name]: e.target.value })
	}

	submitHandler = e => {
		e.preventDefault()
		console.log(this.state)
		axios
			.post('https://localhost:44384/api/AddressCodes', this.state)
			.then(response => {
				console.log(response)
			})
			.catch(error => {
				console.log(error)
			})
	}

	render() {
		const {  city, state,zipCode } = this.state
		return (
    <style>
        body
        {
            background-image:url('https://c1.wallpaperflare.com/preview/551/930/440/contact-us-contact-call-us-phone-communication.jpg');
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
        <h2 style={{color: "blue"}}>Add AddressCode</h2>
			<div>
				<form onSubmit={this.submitHandler}>
					<div>
                    <label className="txt" style={{color: "Blue"}}>Enter City:  </label>
						<input
						    placeholder="Enter City"
							type="text"
							name="city"
							value={city}
							onChange={this.changeHandler}
							required={true}
						/>
					</div>
                    <br></br>
					<div>
                    <label className="txt" style={{color: "Blue"}}>Enter State:  </label>
						<input
						    placeholder="Enter State"
							type="text"
							name="state"
							value={state}
							onChange={this.changeHandler}
							required={true}
						/>
					</div>
                    <br></br>
                    <div>
                    <label className="txt" style={{color: "Blue"}}>Enter ZipCode:  </label>
						<input
						    placeholder="Enter ZipCode"
							type="text"
							name="zipCode"
							value={zipCode}
							onChange={this.changeHandler}
							required={true}
						/>
					</div>
                    <br></br>
					<br></br>
					<button class='buttons' style={{backgroundColor:"blue"}} type="submit">Submit</button>&nbsp;
                    <button class='buttons' style={{backgroundColor:"blue"}}>
					<Link to="AddressCodeTable" className="formFieldLink">

					<a href="/AddressCodeTable" style="color:white">View</a></Link>
					</button>
					
				</form>
                </div>
			</div>
</body>

		)
	}
}

export default AddressCodes;