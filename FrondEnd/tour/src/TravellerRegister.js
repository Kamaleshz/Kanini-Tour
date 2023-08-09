import React, { useState } from 'react';
import axios from 'axios';
import { Modal, Button, Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';

const RegisterAgent = () => {
  const [formData, setFormData] = useState({
    traveller_Name: '',
    traveller_Email: '',
    traveller_Password: '',
    traveller_Contact: '',
  });

  const [validationErrors, setValidationErrors] = useState({});
  const [showSuccessModal, setShowSuccessModal] = useState(false);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const travellerData = {
      traveller_Name: formData.traveller_Name,
      traveller_Email: formData.traveller_Email,
      traveller_Password: formData.traveller_Password,
      traveller_Contact: parseInt(formData.traveller_Contact),
    };

    try {
      await axios.post('https://localhost:7135/api/Traveller', travellerData);
      
      // Show success modal and reset form data
      setShowSuccessModal(true);
      setFormData({
        traveller_Name: '',
        traveller_Email: '',
        traveller_Password: '',
        traveller_Contact: '',
      });
    } catch (error) {
      console.error('Error submitting form', error);
    }
  };

  const handleValidation = () => {
    const errors = {};

    if (!formData.traveller_Name) {
      errors.traveller_Name = 'Traveller Name is required.';
    }
    if (!formData.traveller_Email) {
      errors.traveller_Email = 'Traveller Email is required.';
    } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/i.test(formData.traveller_Email)) {
      errors.traveller_Email = 'Please enter a valid email address.';
    }
    if (!formData.traveller_Password) {
      errors.traveller_Password = 'Password is required.';
    } else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/i.test(formData.traveller_Password)) {
      errors.traveller_Password = 'Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.';
    }
    if (!formData.traveller_Contact) {
      errors.traveller_Contact = 'Traveller Contact is required.';
    } else if (!/^\d{10}$/.test(formData.traveller_Contact)) {
      errors.traveller_Contact = 'Contact must be 10 digits.';
    }

    setValidationErrors(errors);

    return Object.keys(errors).length === 0;
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();

    if (handleValidation()) {
      handleSubmit(e);
    }
  };

  return (
    <div>
    <Navbar bg="light" expand="lg">
        <Container>
        <Navbar.Brand href="#">TourVista</Navbar.Brand>        
        <Navbar.Toggle aria-controls="navbarNav" />
        <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
            <Nav.Link href="/" active>Home</Nav.Link>
            <Nav.Link href="/Filter" active>Package</Nav.Link>
            <Nav.Link href="#">Contact</Nav.Link>
            </Nav>
        </Navbar.Collapse>
        <NavDropdown title="Login" id="basic-nav-dropdown" alignRight>
            <NavDropdown.Item href="/TravellerLogin">Traveller</NavDropdown.Item>
            <NavDropdown.Item href="/AgentLogin">Travel Agent</NavDropdown.Item>
            <NavDropdown.Item href="/AdminLogin">Admin</NavDropdown.Item>
        </NavDropdown>
        </Container>
    </Navbar>
      <div className="container mt-5">
        <div className="row justify-content-center">
          <div className="col-md-6">
            <div className="card bg-light">
              <div className="card">
                <div>
                  <h4 className="card-header">Traveller Register</h4>
                </div>
                <div className="card-body">
                  <Form noValidate onSubmit={handleFormSubmit}>
                    <div className="form-group">
                      <label htmlFor="travellerName">Traveller Name:</label>
                      <Form.Control
                        type="text"
                        id="traveller_Name"
                        name="traveller_Name"
                        value={formData.traveller_Name}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.traveller_Name}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.traveller_Name}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="travellerEmail">Traveller Email:</label>
                      <Form.Control
                        type="email"
                        id="traveller_Email"
                        name="traveller_Email"
                        value={formData.traveller_Email}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.traveller_Email}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.traveller_Email}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="travellerPassword">Traveller Password:</label>
                      <Form.Control
                        type="password"
                        id="traveller_Password"
                        name="traveller_Password"
                        value={formData.traveller_Password}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.traveller_Password}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.traveller_Password}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="travellerContact">Traveller Contact:</label>
                      <Form.Control
                        type="tel"
                        id="traveller_Contact"
                        name="traveller_Contact"
                        value={formData.traveller_Contact}
                        onChange={handleInputChange}
                        pattern="[0-9]{10}"
                        title="Phone number must be 10 digits"
                        required
                        isInvalid={!!validationErrors.traveller_Contact}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.traveller_Contact}
                      </Form.Control.Feedback>
                    </div>
                    <br />
                    <div className="d-flex justify-content-center">
                      <Button type="submit" className="btn btn-primary">
                        Register
                      </Button>
                    </div>
                  </Form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Modal show={showSuccessModal} onHide={() => setShowSuccessModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Registration Successful</Modal.Title>
        </Modal.Header>
        <Modal.Footer>
          <Button variant="primary" onClick={() => {
            setShowSuccessModal(false);
            // Redirect to AgentLogin
            window.location.href = '/TravellerLogin';
          }}>
            OK
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default RegisterAgent;
