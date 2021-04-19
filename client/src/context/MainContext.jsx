import { createContext, useEffect, useState } from 'react';
import {
    getAllDiagnoses,
    getAllDoctors,
    getAllMedicalCards,
    getAllPatients,
    getAllQualifications,
    getAllSpecializations,
} from '../api';
export const MainContext = createContext();

export const MainProvaider = ({ children }) => {
    const [medicalCards, setMedicalCards] = useState({});
    const [doctors, setDoctors] = useState({});
    const [patients, setPatients] = useState({});
    const [qualifications, setQualifications] = useState({});
    const [specializations, setSpecializations] = useState({});
    const [diagnoses, setDiagnoses] = useState({});

    useEffect(() => {
        getAllDiagnoses().then((data) => setDiagnoses(data));
        getAllQualifications().then((data) => setQualifications(data));
        getAllSpecializations().then((data) => setSpecializations(data));
        getAllMedicalCards().then((data) => setMedicalCards(data));
        getAllPatients().then((data) => setPatients(data));
        getAllDoctors().then((data) => setDoctors(data));
    }, []);

    return (
        <MainContext.Provider
            value={{
                medicalCards,
                doctors,
                patients,
                qualifications,
                specializations,
                diagnoses,
            }}
        >
            {children}
        </MainContext.Provider>
    );
};
