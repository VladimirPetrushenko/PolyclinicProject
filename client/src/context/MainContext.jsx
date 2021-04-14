import { createContext, useEffect, useState } from "react";
import { getAllDoctors,getAllMedicalCards, getAllPatients } from "../api";
export const MainContext = createContext()

export const MainProvaider = ({children}) =>{
    const [medicalCards, setMedicalCards] = useState({});
    const [doctors, setDoctors] = useState({});
    const [patients, setPatients] = useState({});
    
    useEffect(()=>{
        getAllMedicalCards().then(data=>setMedicalCards(data));
        getAllPatients().then(data=>setPatients(data));
        getAllDoctors().then(data=>setDoctors(data));
    },[]);
    
    
    return <MainContext.Provider value = {{medicalCards, doctors, patients}} >{children}</MainContext.Provider>
}