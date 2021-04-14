import { Link } from "react-router-dom";
export const Home = () =>{
    return  <div className="Home">
                <p>Выберите пункт, который вам необходим</p>
                <p><Link className="card-action" to="/doctors">Список всех докторов</Link></p>
                <p><Link className="card-action" to="/patients">Список всех пациентов</Link></p>
                <p><Link className="card-action" to="/medicalcards">Список всех медицинских карт</Link></p>
                <p><Link className="card-action" to="/qualifications">Список всех квалификаций</Link></p>
                <p><Link className="card-action" to="/specializations">Список всех специализаций</Link></p>
                <p><Link className="card-action" to="/diagnosis">Список всех диагнозов</Link></p>
            </div>
}