import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Header } from "./components/Header";
import { Footer } from "./components/Footer";

import { DoctorList } from "./components/DoctorList";
import { PatientList } from "./components/PacientList";
import { MedicalCardList } from "./components/MedicalCardList";
import { NotFound } from "./pages/NotFound";
import { Home } from "./pages/Home";
import { Doctor } from "./pages/Doctor";
import { MedicalCard } from "./pages/MedicalCard";
import {MainProvaider} from "./context/MainContext"


function App() {
  return (
    <MainProvaider>
    <div className="App">
      <Router>
        <Header />
        <main className="container content">
          <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/doctors" component={DoctorList} />
            <Route path="/doctor/:id" component={Doctor} />
            <Route path="/patients" component={PatientList} />
            <Route path="/medicalcards" component={MedicalCardList} />
            <Route path="/medicalcard/:id" component={MedicalCard} />
            <Route component={NotFound}/>
          </Switch>
        </main>
        <Footer />
      </Router>
    </div>
    </MainProvaider>
  );
}

export default App;
