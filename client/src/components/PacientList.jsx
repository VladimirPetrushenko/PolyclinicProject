import { useContext } from "react";
import { PatientItem } from "./PacientItem";
import { Preloader } from "./Preloader";
import { MainContext } from "../context/MainContext";

export const PatientList = () => {
    const {patients} = useContext(MainContext)
    return <div className="pacient-list">
        {
        patients.length ? patients.map(patient=>{
            return <PatientItem key={patient.id} {...patient}/>
        }) : <Preloader/>
        }
    </div>
}