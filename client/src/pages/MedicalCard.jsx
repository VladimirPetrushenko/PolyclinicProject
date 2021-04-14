import { useParams,useHistory } from "react-router-dom";
import { useContext } from "react";
import { Preloader } from "../components/Preloader";
import { MainContext } from "../context/MainContext";

export const MedicalCard = () =>{
    const {id} = useParams();
    const {medicalCards} = useContext(MainContext);
    const medicalCard = medicalCards.length ? medicalCards.find(item => item.id.toString()===id) : {};
    const {goBack} = useHistory();

    return  <>
                { !medicalCard.id ? <Preloader /> : (
                    <div className="MedicalCard">
                        <h4>Пациент: {medicalCard.idPatientNavigation.firstName} {medicalCard.idPatientNavigation.lastName}</h4>
                        <h4>Лечащий врач: {medicalCard.idDoctorNavigation.firstName} {medicalCard.idDoctorNavigation.lastName}.</h4> 
                        <h4>Специализация: {medicalCard.idDoctorNavigation.specialization.specialization1}</h4>
                        <br></br><br></br><br></br><br></br>
                        <h4>Диагноз:</h4> 
                        <h5>{medicalCard.idDiagnosisNavigation.diagnosis1}</h5>
                        <h5>Дата посещения врача: {medicalCard.dateOfVisit}</h5>
                        <h6>Протокол иследований: {medicalCard.reaseachProtacol}</h6>
                        <h6>Заключение: {medicalCard.conclusion}</h6>
                        <h6>Рекомендации: {medicalCard.recomendatein}</h6>
                    </div>
                )}
                <p></p>
                <button className="btn" onClick={goBack}>Go Back</button>
            </>
}