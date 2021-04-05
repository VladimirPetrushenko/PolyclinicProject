import { useState, useEffect } from "react";
import { getAllDoctors } from "../api";
import { DoctorItem } from "./DoctorItem";
import { Preloader } from "./Preloader";
export const DoctorList = () => {
    const [doctors, setDoctors] = useState({});

    useEffect(()=>{
        getAllDoctors().then(data=>setDoctors(data));
    },[])
    return <div className="doctor-list">
        {
        doctors.length ? doctors.map(doctor=>{
            return <DoctorItem key={doctor.id} {...doctor}/>
        }) : <Preloader/>
        }
    </div>
}