
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import './style.css';
import {BrowserRouter, Route, Switch,NavLink} from 'react-router-dom';
import Login from './Login';
import Navigation from './Navigation';

import {Home} from './Admin/Home';
import Courses from './Admin/Courses';
import Subjects from './Admin/Subjects';
import SubjectReportCards from './Admin/SubjectReportCards';
import Students from './Admin/Students';
import AddressCodes from './Admin/AddressCodes';


import StudentsTable from './Admin/StudentsTable';
import SrcTable from './Admin/SrcTable';
import SubjectTable from './Admin/SubjectTable';
import CourseTable from './Admin/CourseTable';
import {Logout} from './Admin/Logout';
import AddressCodeTable from './Admin/AddressCodeTable';
import UpdateAddressCode from './Admin/UpdateAddressCode';
 
function App() {
  return (
   

<BrowserRouter>
    <div className="App container">
      <h2 className='head'>ONLINE STUDENT MANAGEMENT SYSTEM</h2>
        
     
      <Switch>
      <Route exact path="/" component={Login} />
            <Route  path="/Login" component={Login} />
      <Navigation/>
      </Switch>

      <Route path='/Home' component={Home}/>
      <Route path='/Courses' component={Courses}/>
        <Route path='/Subjects' component={Subjects}/>
        <Route path='/SubjectReportCards' component={SubjectReportCards}/>
        <Route path='/Students' component={Students}/>
        <Route path='/AddressCodes' component={AddressCodes}/>
        <Route path='/AddressCodeTable' component={AddressCodeTable}/>
        <Route path='/StudentsTable' component={StudentsTable}/>
        <Route path='/SrcTable' component={SrcTable}/>
        <Route path='/SubjectTable' component={SubjectTable}/>
        <Route path='/CourseTable' component={CourseTable}/>
        <Route path='/UpdateAddressCode' component={UpdateAddressCode}></Route>
  <Route path='/Logout' component={Logout}/> 

    </div>
    </BrowserRouter>
  

  );
}
 
export default App;



