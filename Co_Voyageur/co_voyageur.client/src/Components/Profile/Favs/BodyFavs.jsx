import React from 'react';
const BodyFavs = () => {
    const favExample={
        from: "Paris",
        to: "Lyon",
    }
    return (
        <>
            <div className='fav-container'>
                <button className='fav'>{favExample.from} {'>'} {favExample.to}</button>
                <button className='remove-fav'><img src="\Images\Trash.png" alt="remove-fav"/></button>
            </div>
        </>
    );
};

export default BodyFavs;