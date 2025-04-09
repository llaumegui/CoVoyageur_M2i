import React from 'react';
import './ReviewCard.css';
const BodyReviews = () => {
    const reviewExample = {
        profileImage:'https://picsum.photos/50',
        username: 'Toto',
        notation: 3,
    };
     
    return (
        <>
            <div className='review-card'>
                    <img src={reviewExample.profileImage} alt="profile-image" className="profile-image" />
                    <p>{reviewExample.username}</p>
                    <p className="notation">Note: {reviewExample.notation} / 5 <img src="\Images\star.png" alt="" /> </p>
            </div>
        </>
    );
};
export default BodyReviews;