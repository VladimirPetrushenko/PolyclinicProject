import { Link } from "react-router-dom";

export const MedicalCardItem = (props) => {
    const {
        id, 
        idDoctorNavigation, 
        idPatientNavigation, 
        dateOfVisit, 
    } = props;
    return <div className="card blue-grey darken-1" id={id}>
                <div className="card-content white-text">
                    <p>Пациент: {idPatientNavigation.firstName} {idPatientNavigation.lastName}</p>
                    <p>Лечащий врач: {idDoctorNavigation.firstName} {idDoctorNavigation.lastName}. Специализация: {idDoctorNavigation.specialization.specialization1}</p>
                    <p>Дата посещения: {dateOfVisit}</p>
                    </div>
                    <div className="card-action">
                    <Link to={`/medicalcard/${id}`}>Получить более подробную информацию</Link>
                </div>
            </div>
}