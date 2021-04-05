import { useParams,useHistory } from "react-router-dom";
import { useEffect, useState } from "react";
import { getDoctorById } from "../api";
import { Preloader } from "../components/Preloader";

export const Doctor = () =>{
    const {id} = useParams();
    const [doctor, setDoctor] = useState({});
    const {goBack} = useHistory();

    useEffect(()=>{
        getDoctorById(id).then(data=>setDoctor(data));
    },[id]);
    console.log(doctor);
    return  <>
                { !doctor.id ? <Preloader /> : (
                    <div className="Doctor">
                        <h1>{doctor.firstName} {doctor.lastName}</h1>
                        <h6>Возраст: {doctor.age}</h6>
                        <h6>Адрес: {doctor.address}</h6>
                        <h6>Телефон: {doctor.phone}</h6>
                        <h6>Квалификация: {doctor.qualification}</h6>
                        <h6>Специализация: {doctor.specialization}</h6>
                    </div>
                )}
                <p></p>
                <button className="btn" onClick={goBack}>Go Back</button>
            </>
}