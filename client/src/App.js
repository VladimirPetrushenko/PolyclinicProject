import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Header } from "./components/Header";
import { Footer } from "./components/Footer";

import { DoctorList } from "./components/DoctorList";
import { NotFound } from "./pages/NotFound";
import { Home } from "./pages/Home";
import { Doctor } from "./pages/Doctor";



function App() {
  return (
    <div className="App">
      <Router>
        <Header />
        <main className="container content">
          <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/doctors" component={DoctorList} />
            <Route path="/doctor/:id" component={Doctor} />
            <Route component={NotFound}/>
          </Switch>
        </main>
        <Footer />
      </Router>
    </div>
  );
}

export default App;
