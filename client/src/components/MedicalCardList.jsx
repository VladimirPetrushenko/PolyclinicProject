import { useContext } from "react";
import { MedicalCardItem } from "./MedicalCardItem";
import { Preloader } from "./Preloader";
import { MainContext } from "../context/MainContext";

export const MedicalCardList = () => {
    const {medicalCards} = useContext(MainContext);

    return <div className="medical-list">
        {
        medicalCards.length ? medicalCards.map(medicalCard=>{
            return <MedicalCardItem key={medicalCard.id} {...medicalCard}/>
        }) : <Preloader/>
        }
    </div>
}