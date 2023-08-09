import React, { useState, useEffect } from 'react';
import { Navbar, Nav, Container } from 'react-bootstrap';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function AddedPackage() {
  const [packageData, setPackageData] = useState([]);
  const [loading, setLoading] = useState(true);
  const travelagent_Id = sessionStorage.getItem('travelagent_Id');
  const [filteredPackageData, setFilteredPackageData] = useState([]);
  const [deleteSuccess, setDeleteSuccess] = useState(false);
  const [showModal, setShowModal] = useState(false);

  async function fetchData() {
    try {
      const response = await fetch('https://localhost:7297/api/Package');
      const jsonData = await response.json();
      setPackageData(jsonData);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching data:', error);
      setLoading(false);
    }
  }

  useEffect(() => {
    fetchData();
  }, []);

  useEffect(() => {
    if (travelagent_Id && packageData.length > 0) {
      const filteredData = packageData.filter(
        packageItem => packageItem.travelagent_Id == travelagent_Id
      );
      setFilteredPackageData(filteredData);
    }
  }, [travelagent_Id, packageData]);

  const handleDelete = async (packageId) => {
    try {
      const response = await fetch(`https://localhost:7297/api/Package?Package_Id=${packageId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        setDeleteSuccess(true);
        setShowModal(true);
        fetchData(); // Call fetchData to update the packageData after deletion
      } else {
        console.error('Error deleting package:', response.statusText);
      }
    } catch (error) {
      console.error('Error deleting package:', error);
    }
  };
  const handleLogout = () => {
    console.clear();
    sessionStorage.clear();
    window.location.href = '/';
  };

  return (
    <div>
        <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand href="#">Your Logo</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarNav" />
          <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
              <Nav.Link href="/Agent" active>Home</Nav.Link>
              <Nav.Link href="/AgentAddedPackage">Package</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Nav.Link href="#">
              <FontAwesomeIcon icon={faUser} />
            </Nav.Link>
            <Nav.Link href="#" className="ml-2" onClick={handleLogout}>
              Logout
            </Nav.Link>
        </Container>
      </Navbar>
      <h3 className="text-center">Your Packages</h3>
      <div className="container">
        <div className="row">
          {loading ? (
            <p>Loading...</p>
          ) : (
            filteredPackageData.map((packageItem) => (
              <div key={packageItem.package_Id} className="col-md-4 mb-4">
                <div className="card">
                  <img
                    src={`https://localhost:7297/Uploads/${packageItem.package_Image}`}
                    className="card-img-top"
                    alt="Package"
                    style={{ height: '500px', objectFit: 'cover' }}
                  />
                  <div className="card-body">
                    <h5 className="card-title">{packageItem.package_Name}</h5>
                    <p className="card-text">
                      Package Type: {packageItem.package_Type}
                      <br />
                      Rate: {packageItem.package_Rate}
                      <br />
                      Duration: {packageItem.duration}
                      <br />
                      Itinerary: {packageItem.package_Itenary}
                      <br />
                      Food: {packageItem.package_Food}
                      <br />
                      Hotel: {packageItem.package_Hotel}
                    </p>
                    <button
                      className="btn btn-danger"
                      onClick={() => handleDelete(packageItem.package_Id)}
                    >
                      Delete
                    </button>
                  </div>
                </div>
              </div>
            ))
          )}
        </div>
      </div>

      {/* Modal for delete success */}
      <div className={`modal ${showModal ? 'show' : ''}`} tabIndex="-1" role="dialog" style={{ display: showModal ? 'block' : 'none' }}>
        <div className="modal-dialog" role="document">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">Delete Success</h5>
              <button type="button" className="close" onClick={() => setShowModal(false)}>
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              <p>Package has been deleted successfully.</p>
            </div>
            <div className="modal-footer">
              <button type="button" className="btn btn-primary" onClick={() => setShowModal(false)}>Close</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
