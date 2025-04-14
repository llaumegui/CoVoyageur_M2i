import React,{ useState } from 'react';
import '../Card.css';
import './MyCar.css'
const MyCar = () => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isEditingMode, setIsEditingMode] = useState(false);
    const car = {
        model: 'zerez',
        capacity: '' ,
        color: '',
        plate: ''
    };

    const handleOpenModal = () => {
        setIsModalOpen(true);
    };

    const handleCloseModal = () => {
        setIsModalOpen(false);
    };

    const handleEditClick = () => {
        setIsEditingMode(!isEditingMode);
        setIsModalOpen(true);
    }

    const handleEditClose = () => {
        setIsEditingMode(false);
        setIsModalOpen(false);
    }
    return (
        <>
        <div className='card'>
            <div className='card__header'>
                <h2 className='card__header-title'>Mon véhicule</h2>
                {!car.model &&(
                    <button onClick={handleOpenModal}>+</button>
                )}
                    
            </div>
            
            <div className='card__body'>
            {car.model && (
                <>
                <p>Marque: {car.model}</p>
                <p>Capacité: {car.capacity}</p>
                <p>Couleur: {car.color}</p>
                <p>Immatriculation: {car.plate}</p>
                </>
            )}
                
            </div>
            <div className='card__footer'>
                {car.model && (
                    <button className='card__footer-button-edit' onClick={handleEditClick}>Modifier</button>
                )}
                
            </div>
        </div>

        {isModalOpen && (
            <div className='modal'>
                <div className='modal__content'>
                                {isEditingMode ? (
                                    <>
                                    <h3>Modifier mon véhicule</h3>
                                    <form>
                                    <input type="text" placeholder="Modèle" value={car.model}/>
                                    <input type="number" placeholder="Capacité" value={car.capacity}/>
                                    <input type="text" placeholder="Couleur" value={car.color}/>
                                    <input type="text" placeholder="Immatriculation"value={car.plate} />
                                    <button>Modifier</button>
                                    
                                    </form>
                                    <button className='modal__close' onClick={handleEditClose}>
                                Fermer
                            </button>
                                    </>
                                ):(
                                    <>
                                    <h3>Ajouter un véhicule</h3>
                                    <form>
                                    <input type="text" placeholder="Modèle"/>
                                    <input type="number" placeholder="Capacité" />
                                    <input type="text" placeholder="Couleur" />
                                    <input type="text" placeholder="Immatriculation" />
                                    <button type="submit">Ajouter</button>
                                    </form>
                                    <button className='modal__close' onClick={handleCloseModal}>
                                    Fermer
                                    </button>
                                    </>
                                )}
                                
                            
                </div>
            </div>
        )}
        </>
    );
};

export default MyCar;