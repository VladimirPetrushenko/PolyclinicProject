import { useParams,useHistory } from "react-router-dom";
import { useContext } from "react";
import { Preloader } from "../components/Preloader";
import { MainContext } from "../context/MainContext";

export const Doctor = () =>{
    const {id} = useParams();
    const {doctors} = useContext(MainContext);
    const doctor = doctors.length ? doctors.find(doctor=> doctor.id.toString()===id) : {};
    const {goBack} = useHistory();

    return  <>
                { !doctor.id ? <Preloader /> : (
                    <div className="Doctor">
                        <h1>{doctor.firstName} {doctor.lastName}</h1>
                        <h6>Возраст: {doctor.age}</h6>
                        <h6>Адрес: {doctor.address}</h6>
                        <h6>Телефон: {doctor.phone}</h6>
                        <h6>Квалификация: {doctor.qualification.name}</h6>
                        <h6>Специализация: {doctor.specialization.specialization1}</h6>
                    </div>
                )}
                <p></p>
                <button className="btn" onClick={goBack}>Go Back</button>
            </>
}