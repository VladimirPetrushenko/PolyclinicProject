import { Link } from "react-router-dom";

export const PatientItem = (props) => {
    const {id, age, firstName, lastName, address} = props;
    return <div className="card blue-grey darken-1" id={id}>
                <div className="card-content white-text">
                    <span className="card-title">{firstName} {lastName}</span>
                    <p>{age}</p>
                    <p>{address}</p>
                    </div>
                    <div className="card-action">
                    <Link to={`/pacient/${id}`}>Перейти на страничку пациента</Link>
                </div>
            </div>
}