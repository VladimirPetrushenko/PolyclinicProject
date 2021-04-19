var cur = window.location;
const {hostname} = cur;

export const getAllDoctors= async () => {
    const response = await fetch(`http://${hostname}:8080/api/Doctors/`);
    return await response.json();
}

export const getDoctorById= async (id) => {
    const response = await fetch(`http://${hostname}:8080/api/Doctors/${id}`);
    return await response.json();
}

export const postDoctor = (doctor = {}) => {
    var response = fetch(`http://${hostname}:8080/api/Doctors/`, {
        method: 'POST', 
        body: JSON.stringify(doctor),
        headers: {
            'Content-Type': 'application/json'
        },
    });
    return response;
}

export const getAllPatients= async () => {
    const response = await fetch(`http://${hostname}:8080/api/Patients/`);
    return await response.json();
}

export const getPatientById= async (id) => {
    const response = await fetch(`http://${hostname}:8080/api/Patients/${id}`);
    return await response.json();
}


export const getAllMedicalCards= async () => {
    const response = await fetch(`http://${hostname}:8080/api/MedicalCards`);
    return await response.json();
}

export const getMedicalCardById= async (id) => {
    const response = await fetch(`http://${hostname}:8080/api/MedicalCards/${id}`);
    return await response.json();
}
export const getAllQualifications= async () => {
    const response = await fetch(`http://${hostname}:8080/api/Qualifications/`);
    return await response.json();
}
export const getAllSpecializations= async () => {
    const response = await fetch(`http://${hostname}:8080/api/Specializations/`);
    return await response.json();
}
export const getAllDiagnoses = async () => {
    const response = await fetch(`http://${hostname}:8080/api/Diagnoses/`);
    return await response.json();
}