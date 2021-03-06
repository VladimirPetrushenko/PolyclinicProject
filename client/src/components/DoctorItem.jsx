import { Link } from "react-router-dom";

export const DoctorItem = (props) => {
    const {id, age, firstName, lastName, address, specialization, qualification} = props;
    return <div className="card blue-grey darken-1" id={id}>
                <div className="card-content white-text">
                    <span className="card-title">{firstName} {lastName}</span>
                    <p>{age}</p>
                    <p>{address}</p>
                    <p>{specialization.specialization1}</p>
                    <p>{qualification.name}</p>
                    </div>
                    <div className="card-action">
                    <Link to={`/doctor/${id}`}>Перейти на страничку доктора</Link>
                </div>
            </div>
}