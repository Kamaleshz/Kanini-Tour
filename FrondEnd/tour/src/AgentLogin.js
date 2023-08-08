import React, { useState } from 'react';
import { useNavigate , Link } from 'react-router-dom';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const AgentLogin = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7297/api/AgentToken/Authenticate', {
        email,
        password,
      });

      const token = response.data.token;
      const travelagent_Id = response.data.travelagent_Id;

      if (!token) {
        toast.error('Token ID not generated. Please check your credentials.');
        return;
      }

      sessionStorage.setItem('travelagent_Id', travelagent_Id);
      sessionStorage.setItem('Token', token);

      setIsLoggedIn(true);

      navigate('/Agent');
    } catch (error) {
      console.error('Error:', error);
      toast.error('Login credentials seems wrong or your account is not activated yet. Please try again.'); 
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div>
            <h4 className="card-header">Travel Agent Login</h4>
            </div>
            <div className="card-body">
              <div className="mb-3">
                <label className="form-label">Email:</label>
                <input
                  type="email"
                  className="form-control"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Password:</label>
                <input
                  type="password"
                  className="form-control"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <button className="btn btn-primary" onClick={handleLogin}>
                Login
              </button>
              <p className="mt-3">
                New user? <Link to="/AgentRegister">Sign up Here</Link>
              </p>
            </div>
          </div>
        </div>
      </div>
      <ToastContainer />
    </div>
  );
  
};

export default AgentLogin;
