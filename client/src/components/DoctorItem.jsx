import { Link } from "react-router-dom";
export const DoctorItem = (props) => {
    const {id, age, firstName, lastName, address,idSpecializationNavigation, qualification} = props

    return <div className="card blue-grey darken-1" id={id}>
                <div className="card-content white-text">
                    <span className="card-title">{firstName} {lastName}</span>
                    <p>{age}</p>
                    <p>{address}</p>
                    <p>{idSpecializationNavigation}</p>
                    <p>{qualification}</p>
                    </div>
                    <div className="card-action">
                    <Link to={`/doctor/${id}`}>Перейти на страничку доктора</Link>
                </div>
            </div>
}