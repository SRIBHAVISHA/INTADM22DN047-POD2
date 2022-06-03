import { Navbar, Nav} from "react-bootstrap";
import { useHistory,Link} from "react-router-dom";
import React,{useEffect ,useState } from "react";
  function Navigation() {
  const history = useHistory();
   function logout() {
    localStorage.clear();
    history.push("/Login");
    window.location.reload(false);
  }
  let role =sessionStorage.getItem("role");
  const [user, setData] = useState(role);
  function AdminLogin() {
    setData("Admin");
  }
  console.log(user);
  if (user == "Admin") {
    return (
      <header>
         
        <Navbar bg="dark" expand="lg" variant="dark">
          <Navbar.Brand href="/"> Admin</Navbar.Brand>
         
                <nav className="topnav">
                <ul className="navbar-nav"></ul>
                     
                    <Nav.Link href="/Home" >Home</Nav.Link>
                     <Nav.Link href="/Courses" >Courses</Nav.Link>
                    <Nav.Link href="/Subjects" >Subjects</Nav.Link>
                     <Nav.Link href="/SubjectReportCards">SubjectReportCards</Nav.Link>
                    <Nav.Link href="/Students" >Students</Nav.Link>
                    <Nav.Link href="/AddressCodes" >AddressCodes</Nav.Link>
                    
                     <Nav className="ms-auto">
                     <Nav.Link onClick={logout}>Logout</Nav.Link>
                     </Nav>
                 
  </nav>
        
        </Navbar>
        
           
      </header>
    );
  } 

   else {
    return (
      <header>
      <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container-fluid">
        <a className="navbar-brand" href="#"></a>
        <div className="d-flex justify-content-end">
          <div
            className=" collapse navbar-collapse"
            id="navbarSupportedContent"
          >
            <button
              class="navbar-toggler"
              type="button"
              data-bs-toggle="collapse"
              data-bs-target="#main_nav"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
              <span class="navbar-toggler-icon"></span>
            </button>
            
          </div>
        </div>
      </div>
    </nav>
  </header>
  );
}
}
export default Navigation;