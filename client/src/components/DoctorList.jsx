import { useContext } from "react";
import { DoctorItem } from "./DoctorItem";
import { Preloader } from "./Preloader";
import { MainContext } from "../context/MainContext";

export const DoctorList = () => {
    const {doctors} = useContext(MainContext)

    return <div className="doctor-list">
        {
        doctors.length ? doctors.map(doctor=>{
            return <DoctorItem key={doctor.id} {...doctor}/>
        }) : <Preloader/>
        }
    </div>
}