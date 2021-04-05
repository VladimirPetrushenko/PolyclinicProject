export const getAllDoctors= async () => {
    const response = await fetch("https://localhost:44358/api/Doctors/");
    return await response.json();
}

export const getDoctorById= async (id) => {
    const response = await fetch(`https://localhost:44358/api/Doctors/${id}`);
    return await response.json();
}