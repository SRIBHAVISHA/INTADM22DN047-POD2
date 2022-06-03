import React, { setState, Component } from "react";  
 
import AddressCodes from "../DbServices/AddressCodes";  
class UpdateAddressCode extends React.Component {  
  constructor() {  
    super();  
    this.state = {  
      AddressCodes: [],  
      addressCodeId: "",  
      city: "",  
      state: "",  
      zipCode: "",  
       
    };  
    this.selectedId = 0;  
    this.UpdateAddressCode = this.UpdateAddressCode.bind(this);  
    this.onChange = this.onChange.bind(this);  
  }  
  onChange(event) {  
    this.setState({ [event.target.name]: event.target.value });  
  }  
  
  UpdateAddressCode() {  
    let obj = {};  
    obj.addressCodeId = this.state.addressCodeId;  
    obj.city = this.state.city;  
    obj.state = this.state.state;  
    obj.zipCode= this.state.zipCode;  
     
     console.log(obj); 
  
    AddressCodes.updateAddressCode(this.state.addressCodeId, obj).then((resData) => {  
      this.setState({  
        result: resData.data.result,  
        addressCodeId: "",  
        city: "",  
        state: "",  
        zipCode:"",  
         
      });  
      //this.getData();  
      console.log(resData.data); 
    });  
  }  
  render() {  
    return (  
      <div>  
        <center>  
          <h1>Update Details</h1>  
        </center>  
        <div className="form">  
           
            <label>addressCodeId</label>  
            <input 
          placeholder="Enter addressCodeId" 
       type="text" 
       name="addressCodeId" 
       value={this.state.addressCodeId} 
       onChange={this.onChange} 
       required={true} 
      /><br></br> 
 
    <label>city</label>  
       <input type="text" Name="city" value={this.state.city} onChange={this.onChange} placeholder="City Name" /> 
            <br></br> 
    <label>state</label>  
            <input  
              type="text"  
              name="state"  
              value={this.state.state}  
              
              placeholder=" Enter state"  
              required  
              onChange={this.onChange}  
            />  
            <br></br> 
    <label>zipCode</label>  
            <input  
              type="text"  
              name="zipCode"  
              value={this.state.zipCode}  
           
              placeholder=" Enter zipCode"  
              required  
              onChange={this.onChange}  
            />  
            <br></br> 
            
  
            
            <button onClick={this.UpdateAddressCode}>Update</button>  
              
          
        </div>  
      </div>  
    );  
  }  
}  
export default UpdateAddressCode;