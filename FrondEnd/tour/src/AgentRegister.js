import React, { useState } from 'react';
import axios from 'axios';
import { Modal, Button, Container, Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const RegisterAgent = () => {
  const [formData, setFormData] = useState({
    travelagent_Name: '',
    travelagency_Name: '',
    travelagent_Description: '',
    travelagent_Contact: '',
    travelagent_Email: '',
    travelagent_Password: '',
    travelagent_Status: '',
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

    const formDataObject = new FormData();
    for (const key in formData) {
      formDataObject.append(key, formData[key]);
    }

    try {
      await axios.post('https://localhost:7297/api/Agent', formDataObject, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      // Show success modal and reset form data
      setShowSuccessModal(true);
      setFormData({
        travelagent_Name: '',
        travelagency_Name: '',
        travelagent_Description: '',
        travelagent_Contact: '',
        travelagent_Email: '',
        travelagent_Password: '',
        travelagent_Status: '',
      });
    } catch (error) {
      console.error('Error submitting form', error);
    }
  };

  const handleValidation = () => {
    const errors = {};

    if (!formData.travelagent_Name) {
      errors.travelagent_Name = 'Agent Name is required.';
    }
    if (!formData.travelagency_Name) {
      errors.travelagency_Name = 'Agency Name is required.';
    }
    if (!formData.travelagent_Contact) {
      errors.travelagent_Contact = 'Agent Contact is required.';
    } else if (!/^\d{10}$/.test(formData.travelagent_Contact)) {
      errors.travelagent_Contact = 'Contact must be 10 digits.';
    }
    if (!formData.travelagent_Email) {
      errors.travelagent_Email = 'Agent Email is required.';
    } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/i.test(formData.travelagent_Email)) {
      errors.travelagent_Email = 'Please enter a valid email address.';
    }
    if (!formData.travelagent_Password) {
      errors.travelagent_Password = 'Password is required.';
    } else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/i.test(formData.travelagent_Password)) {
      errors.travelagent_Password = 'Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.';
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
      <div className="container mt-5">
        <div className="row justify-content-center">
          <div className="col-md-6">
            <div className="card bg-light">
              <div className="card">
              <div>
            <h4 className="card-header">Travel Agent Register</h4>
            </div>
                <div className="card-body">
                  <Form noValidate onSubmit={handleFormSubmit}>
                    <div className="form-group">
                      <label htmlFor="agentName">Agent Name:</label>
                      <Form.Control
                        type="text"
                        id="travelagent_Name"
                        name="travelagent_Name"
                        value={formData.travelagent_Name}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.travelagent_Name}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.travelagent_Name}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="agencyName">Agency Name:</label>
                      <Form.Control
                        type="text"
                        id="travelagency_Name"
                        name="travelagency_Name"
                        value={formData.travelagency_Name}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.travelagency_Name}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.travelagency_Name}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="agentDescription">Agent Description:</label>
                      <Form.Control
                        type="text"
                        id="travelagent_Description"
                        name="travelagent_Description"
                        value={formData.travelagent_Description}
                        onChange={handleInputChange}
                        required
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="agentContact">Agent Contact:</label>
                      <Form.Control
                        type="tel"
                        id="travelagent_Contact"
                        name="travelagent_Contact"
                        value={formData.travelagent_Contact}
                        onChange={handleInputChange}
                        pattern="[0-9]{10}"
                        title="Phone number must be 10 digits"
                        required
                        isInvalid={!!validationErrors.travelagent_Contact}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.travelagent_Contact}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="agentEmail">Agent Email:</label>
                      <Form.Control
                        type="email"
                        id="travelagent_Email"
                        name="travelagent_Email"
                        value={formData.travelagent_Email}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.travelagent_Email}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.travelagent_Email}
                      </Form.Control.Feedback>
                    </div>
                    <div className="form-group">
                      <label htmlFor="agentPassword">Agent Password:</label>
                      <Form.Control
                        type="password"
                        id="travelagent_Password"
                        name="travelagent_Password"
                        value={formData.travelagent_Password}
                        onChange={handleInputChange}
                        required
                        isInvalid={!!validationErrors.travelagent_Password}
                      />
                      <Form.Control.Feedback type="invalid">
                        {validationErrors.travelagent_Password}
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
      <Modal.Body>
        Registered successfully. Your account will be activated within a week.
      </Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={() => {
          setShowSuccessModal(false);
          // Redirect to AgentLogin
          window.location.href = '/AgentLogin';
        }}>
          OK
        </Button>
      </Modal.Footer>
    </Modal>
  </div>
  );
};

export default RegisterAgent;
