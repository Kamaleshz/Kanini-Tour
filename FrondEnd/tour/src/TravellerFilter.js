import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';

function App() {
  const [data, setData] = useState([]);
  const [selectedType, setSelectedType] = useState('All'); // Updated state and variable names
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await fetch('https://localhost:7297/api/Package');
        const jsonData = await response.json();

        const packagesWithHover = jsonData.map(item => ({ ...item, isHovered: false }));
        setData(packagesWithHover);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }

    fetchData();
  }, []);

  const handleCardClick = (packageId) => {
    sessionStorage.setItem('package_Id', packageId);
    navigate('/Spot');
  };

  const handleMouseOver = (packageId) => {
    setData(prevData => {
      return prevData.map(item => {
        if (item.package_Id === packageId) {
          return { ...item, isHovered: true };
        }
        return item;
      });
    });
  };

  const handleMouseOut = (packageId) => {
    setData(prevData => {
      return prevData.map(item => {
        if (item.package_Id === packageId) {
          return { ...item, isHovered: false };
        }
        return item;
      });
    });
  };

  const handleLogout = () => {
    console.clear();
    sessionStorage.clear();
    window.location.href = '/';
  };

  const filteredData = selectedType === 'All' // Updated condition
    ? data
    : data.filter(item => item.package_Type === selectedType);

  const uniqueTypes = [...new Set(data.map(item => item.package_Type))]; // Updated variable name

  return (
    <div>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand href="#">TourVista</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarNav" />
          <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
              <Nav.Link href="/" active>Home</Nav.Link>
              <Nav.Link href="/AllPackage" active>Package</Nav.Link>
              <Nav.Link href="/Filter" active>Filter</Nav.Link>
              <Nav.Link href="#">Contact</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Nav.Link href="#" className="ml-2" onClick={handleLogout}>
            Logout
          </Nav.Link>
        </Container>
      </Navbar>
      <div className="container mt-4">
        <div className="row">
          {/* Dropdown for filtering by package type */}
          <div className="col-md-12 mb-4">
            <NavDropdown
              title={`Filter by Type: ${selectedType}`} // Updated text
              id="package-type-dropdown" // Updated ID
            >
              <NavDropdown.Item onClick={() => setSelectedType('All')}>All</NavDropdown.Item>
              {uniqueTypes.map(type => ( // Updated variable name
                <NavDropdown.Item
                  key={type}
                  onClick={() => setSelectedType(type)}
                >
                  {type}
                </NavDropdown.Item>
              ))}
            </NavDropdown>
          </div>

          {/* Display filtered data */}
          {filteredData.map(item => (
            <div
              key={item.package_Id}
              className="col-md-4 mb-4"
              onClick={() => handleCardClick(item.package_Id)}
              onMouseOver={() => handleMouseOver(item.package_Id)}
              onMouseOut={() => handleMouseOut(item.package_Id)}
              style={{
                transition: "box-shadow 0.3s, transform 0.3s",
                boxShadow: item.isHovered ? "0 0 10px rgba(0, 0, 0, 0.5)" : "none",
                transform: item.isHovered ? "scale(1.05)" : "none"
              }}
            >
              <div className="card">
                <img
                  src={`https://localhost:7297/Uploads/${item.package_Image}`}
                  className="card-img-top"
                  alt={item.location_Name}
                  style={{ height: '450px', objectFit: 'cover' }}
                />
                <div className="card-body">
                  <h5 className="card-title">{item.package_Name}</h5>
                  <p className="card-text">Type: {item.package_Type}</p>
                  <p className="card-text">Rate: {item.package_Rate}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default App;
