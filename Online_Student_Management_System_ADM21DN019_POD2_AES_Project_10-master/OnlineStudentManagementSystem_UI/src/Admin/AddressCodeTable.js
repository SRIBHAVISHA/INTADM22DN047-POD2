import React, { useState, useEffect } from 'react'; 
import axios from 'axios'; 
import { Card, CardBody, CardHeader, Col, Row, Table } from 'reactstrap'; 
import { Link } from "react-router-dom";

 
function AddressCodeTable(props) { 
    const [data, setData] = useState([]); 
 
    useEffect(() => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/AddressCodes/'); 
            setData(result.data); 
        } 
        GetData(); 
    } 
        , []); 
 
    const DeleteAddresscode = (addressCodeId) => { 
        axios.delete('https://localhost:44384/api/AddressCodes/'+addressCodeId) 
            .then((result) => { 
                const GetData = async () => { 
                    const result = await axios.get('https://localhost:44384/api/AddressCodes/'); 
                    setData(result.data); 
                } 
                GetData(); 
            }) 
            .catch((error) => { 
                alert(error); 
            }); 
             
    } 
    const GetAddresscode = (addressCodeId) => { 
        const GetData = async () => { 
            const result = await axios.get('https://localhost:44384/api/AddressCodes/'+addressCodeId); 
            var resultarray=[]; 
            resultarray.push(result.data); 
 
            setData(resultarray); 
            console.log(result.data) 
        } 
        GetData(); 
    } 
    const[book, setBook] = useState({addressCodeId:''}); 
    const onChange =(e)=>{ 
        e.persist(); 
        setBook({...book,[e.target.name]:e.target.value}); 
      } 

      const UpdateAddressCode = (id) => {
        props.history.push({
            pathname: '/UpdateAddressCode/' + id
        });
      }
    
     
   
          
return ( 
    <style>
        body
        {
            background-image:url('https://www.mailboxvalidator.com/resources/wp-content/uploads/2020/01/mbv_articles_img25_syntax_rtc.png');
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
 
                        <i className="fa fa-align-justify"></i> AddressCodes 
                    </CardHeader> 
                    <CardBody> 
                        <div> 
                            <input type="text" name="addressCodeId" onChange={onChange} value={book.addressCodeId} className="form-control ml-2"placeholder='Address Code ID'/> 
                             
                            <div className='input-group-append'> 
                                <button onClick={() => GetAddresscode(book.addressCodeId)} className='btn btn-sm btn-primary' >Get By Id</button> 
                            </div> 
                        </div> 
                        <Table hover bordered striped responsive size="sm"> 
                            <thead> 
                                <tr> 
                                    <th>AddressCodeId</th> 
                                    <th>City</th> 
                                    <th>State</th> 
                                    <th>ZipCode</th> 
                                </tr> 
                            </thead> 
                            <tbody> 
                                { 
                                     data.map((item, idx) => { 
                                        return <tr key={idx}> 
                                            <td>{item.addressCodeId}</td> 
                                            <td>{item.city}</td> 
                                            <td>{item.state}</td> 
                                            <td>{item.zipCode}</td> 
                                            <td> 
                                                <div className="btn-group"> 
                                                <button className="btnbtn-warning" onClick={() => UpdateAddressCode(item.addressCodeId)}>Update</button>
                                                    <button className="btnbtn-warning" onClick={() => DeleteAddresscode(item.addressCodeId)}>Delete</button>
                                                    
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
export default AddressCodeTable;