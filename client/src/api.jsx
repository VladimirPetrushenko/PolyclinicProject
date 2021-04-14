export const getAllDoctors= async () => {
    const response = await fetch("https://localhost:44358/api/Doctors/");
    return await response.json();
}

export const getDoctorById= async (id) => {
    const response = await fetch(`https://localhost:44358/api/Doctors/${id}`);
    return await response.json();
}

export const getAllPatients= async () => {
    const response = await fetch("https://localhost:44358/api/Patients/");
    return await response.json();
}

export const getPatientById= async (id) => {
    const response = await fetch(`https://localhost:44358/api/Patients/${id}`);
    return await response.json();
}


export const getAllMedicalCards= async () => {
    const response = await fetch("https://localhost:44358/api/MedicalCards");
    return await response.json();
}

export const getMedicalCardById= async (id) => {
    const response = await fetch(`https://localhost:44358/api/MedicalCards/${id}`);
    return await response.json();
}