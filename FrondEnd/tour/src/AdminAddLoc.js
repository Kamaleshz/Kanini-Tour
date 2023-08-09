import React, { useState } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

function App() {
  const [data, setData] = useState({
    location_Name: '',
    image: '',
  });

  const handleImageInputChange = (event) => {
    const file = event.target.files[0];
    setData((prevData) => ({
      ...prevData,
      image: file,
    }));
  };

  const handleNameInputChange = (event) => {
    const { value } = event.target;
    setData((prevData) => ({
      ...prevData,
      location_Name: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const url = 'https://localhost:7297/api/Location';

    try {
      const formData = new FormData();
      formData.append('location_Name', data.location_Name);
      formData.append('image', data.image);

      const response = await axios.post(url, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      if (response.status === 200) {
        console.log('Data posted successfully');
      } else {
        console.error('Failed to post data');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  function clearSessionStorage() {
    sessionStorage.clear();
  }

  return (
    <div>
    <Navbar bg="light" expand="lg">
        <Container>
        <Navbar.Brand href="#">TourVista</Navbar.Brand>
        
        <Navbar.Toggle aria-controls="navbarNav" />
        <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
            <Nav.Link href="/AdminLanding" active>Home</Nav.Link>
            <Nav.Link href="/Requested">Requested</Nav.Link>
            <Nav.Link href="/Accepted">Accepted</Nav.Link>
            <Nav.Link href="/Full">Full</Nav.Link>
            <Nav.Link href="/Add">Location</Nav.Link>
            </Nav>
        </Navbar.Collapse>
        
        <Nav.Link href="#">
            <FontAwesomeIcon icon={faUser} />
        </Nav.Link>
        <Nav.Link href="/" onClick={clearSessionStorage} className="ml-2">Logout</Nav.Link>
        </Container>
    </Navbar>
    <div className="container">
    <div className="row justify-content-center">
        <div className="col-md-6">
        <div className="card">
            <div className="card-body">
            <h4 className="card-title">Adding Location</h4>
            <form onSubmit={handleSubmit} encType="multipart/form-data">
                <div className="form-group">
                <label htmlFor="locationName">Location Name:</label>
                <input
                    type="text"
                    className="form-control"
                    id="locationName"
                    name="location_Name"
                    value={data.location_Name}
                    onChange={handleNameInputChange}
                />
                </div>
                <div className="form-group">
                <label htmlFor="locationImage">Location Image:</label>
                <input
                    type="file"
                    className="form-control-file"
                    id="locationImage"
                    name="image"
                    onChange={handleImageInputChange}
                />
                </div>
                <div className="d-flex justify-content-center">
                <button type="submit" className="btn btn-primary">Submit</button>
                </div>
            </form>
            </div>
        </div>
        </div>
    </div>
    </div>
    </div>
  );
}

export default App;
