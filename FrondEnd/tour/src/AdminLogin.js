import React, { useState } from 'react';
import { useNavigate , Link } from 'react-router-dom';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const AdminLogin = () => {
  const [admin_Email, setEmail] = useState('');
  const [admin_Password, setPassword] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7236/api/Admin/Authenticate', {
        admin_Email,
        admin_Password,
      });

      const token = response.data;

      if (!token) {
        toast.error('Token ID not generated. Please check your credentials.');
        return;
      }

      sessionStorage.setItem('Token',token)

      setIsLoggedIn(true);

      navigate("/AdminLanding");
    } catch (error) {
      console.error('Error:', error);
      toast.error('Login credentials seems wrong. Please try again.'); 
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div>
            <h4 className="card-header">Admin Login</h4>
            </div>
            <div className="card-body">
              <div className="mb-3">
                <label className="form-label">Email:</label>
                <input
                  type="email"
                  className="form-control"
                  value={admin_Email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Password:</label>
                <input
                  type="password"
                  className="form-control"
                  value={admin_Password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <button className="btn btn-primary" onClick={handleLogin}>
                Login
              </button>
            </div>
          </div>
        </div>
      </div>
      <ToastContainer />
    </div>
  );
  
};

export default AdminLogin;
