import React from "react";
import styles from "./styles/Hand.module.css";
import {HandProps} from "../types/HandProps";
import Card from "./Card";

const Hand: React.FC<HandProps> = ({ cards }) => {
  const getCards = () => {
    return cards.map((card, index) => {
      return (
        <div key={index}>
            <Card value={card.value} suit={card.suit} hidden={card.hidden} />
        </div>
      );
    });
  };

  return <div className={styles.hand}>{getCards()}</div>;
};

export default Hand;

