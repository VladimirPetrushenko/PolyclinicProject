import { useContext, useState } from 'react';
import { MainContext } from '../context/MainContext';
import { postDoctor } from '../api';

export const DoctorPost = () => {
    const [age, setAge] = useState(0);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [address, setAddress] = useState('');
    const [phone, setPhone] = useState('');
    const [qualificationId, setQualificationId] = useState(2);
    const [specializationId, setSpecializationId] = useState(1);

    const { qualifications, specializations } = useContext(MainContext);

    const handleChangeQualification = (event) => {
        setQualificationId(Number(event.target.value));
    };

    const handleChangeSpecialization = (event) => {
        setSpecializationId(Number(event.target.value));
    };
    const handleSubmit = () => {
        postDoctor({age,firstName,lastName,address,phone,qualificationId,specializationId});
        alert('Данные отправлены на сервер');
        isClear();
    };

    const isClear = () => {
        setAge(0);
        setFirstName('');
        setLastName('');
        setPhone('');
        setAddress('')
        setQualificationId(2);
        setSpecializationId(1);
    }

    return (
        <>
            <h1>Добавление Доктора в базу</h1>
            <p>
                Возраст:{' '}
                <input
                    type="number"
                    id="age"
                    placeholder="Age"
                    onChange={(e) => setAge(e.target.value)}
                    value={age}
                />
            </p>
            <p>
                Имя:{' '}
                <input
                    type="text"
                    id="firstName"
                    placeholder="First Name"
                    onChange={(e) => setFirstName(e.target.value)}
                    value={firstName}
                />
            </p>
            <p>
                Фамилия:{' '}
                <input
                    type="text"
                    id="lastName"
                    placeholder="Last Name"
                    onChange={(e) => setLastName(e.target.value)}
                    value={lastName}
                />
            </p>
            <p>
                Адрес:{' '}
                <input
                    type="text"
                    id="address"
                    placeholder="Address"
                    onChange={(e) => setAddress(e.target.value)}
                    value={address}
                />
            </p>
            <p>
                Телефон:{' '}
                <input
                    type="text"
                    id="phone"
                    placeholder="Phone"
                    onChange={(e) => setPhone(e.target.value)}
                    value={phone}
                />
            </p>
            <div>
                Квалификация:
                <div className="input-field col s12">
                    <select value={qualificationId} onChange={handleChangeQualification}>
                        {qualifications.length
                            ? qualifications.map((qualification) => {
                                  return (
                                      <option
                                          key={qualification.id}
                                          value={qualification.id}
                                      >
                                          {qualification.name}
                                      </option>
                                  );
                              })
                            : null}
                    </select>
                </div>
            </div>
            <div>
              Специализация:
              <div className="input-field col s12">
                  <select value={specializationId} onChange={handleChangeSpecialization}>
                      {specializations.length
                          ? specializations.map((specialization) => {
                                return (
                                    <option
                                        key={specialization.id}
                                        value={specialization.id}
                                    >
                                        {specialization.specialization1}
                                    </option>
                                );
                            })
                          : null}
                  </select>
              </div>
            </div>
            <button className="btn" onClick={handleSubmit}>
              Отправить
            </button>
        </>
    );
};
