import './App.css';
import AdminLogin from './AdminLogin';
import Page from './AdminLanding';
import Req from './AdminReqList';
import Acc from './AdminAccList';
import Full from './AdminFullList';
import add from './AdminAddLoc';
import agentlanding from './AgentLanding';
import agentlogin from './AgentLogin';
import addpack from './AgentAddPackage';
import addspot from './AgentAddSpot';
import addagent from './AgentRegister';
import addedpackage from './AgentAddedPackage';
import PrivateRoute from './PrivateRouter';
import Home from './TravellerLanding';
import Package from './TravellerPackage';
import Spot from './TravellerSpots';
import TravellerLogin from './TravellerLogin';
import Booking from './TravellerBooking';
import Payment from './TravellerPayment';
import Status from './TravellerBookingStatus';
import TravellerRegister from './TravellerRegister';
import filter from './TravellerFilter';
import allpack from './TravellerAllPackage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';


function App() {
  return (
<div>
      <BrowserRouter>
      <Routes>
        <Route path="/AdminLanding" element={<PrivateRoute roles={['Admin']} component={Page}/>}></Route>
        <Route path="/Requested" element={<PrivateRoute roles={['Admin']}component={Req}/>}></Route>
        <Route path="/Accepted" element={<PrivateRoute roles={['Admin']}component={Acc}/>} ></Route>
        <Route path="/Full" element={<PrivateRoute roles={['Admin']} component={Full}/>}></Route>
        <Route path="/Add" element={<PrivateRoute roles={['Admin']} component={add}/>}></Route>
        <Route path="/Agent" element={<PrivateRoute roles={['TravelAgent']} component={agentlanding}/>}></Route>
        <Route path="/AgentLogin" Component={agentlogin}></Route>
        <Route path="/AddPackage" element={<PrivateRoute roles={['TravelAgent']} component={addpack}/>}></Route>
        <Route path="/AddSpots" element={<PrivateRoute roles={['TravelAgent']} component={addspot}/>}></Route>
        <Route path="/AgentRegister" Component={addagent}></Route>
        <Route path="/AgentAddedPackage" element={<PrivateRoute roles={['TravelAgent']} component={addedpackage}/>}></Route>
        <Route path="/AdminLogin" Component={AdminLogin}></Route>
        <Route path="/" Component={Home}></Route>
        <Route path="/Package" Component={Package}></Route>
        <Route path="/Spot" Component={Spot}></Route>
        <Route path="/TravellerLogin" Component={TravellerLogin}></Route>
        <Route path="/Booking" Component={Booking}></Route>
        <Route path="/Payment" Component={Payment}></Route>
        <Route path="/Status" Component={Status}></Route>
        <Route path="/TravellerRegister" Component={TravellerRegister}></Route>
        <Route path="/Filter" Component={filter}></Route>
        <Route path="/AllPackage" Component={allpack}></Route>
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
