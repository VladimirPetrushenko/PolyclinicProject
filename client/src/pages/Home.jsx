import { Link } from "react-router-dom";
export const Home = () =>{
    return  <div className="Home">
                <p>Выберите пункт, который вам необходим</p>
                <Link to="/doctors">Список всех докторов</Link>
            </div>
}