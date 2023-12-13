import React from "react";
import styles from "./styles/Card.module.css";
import {CardProps} from "../types/CardProps";


const Card: React.FC<CardProps> = ({ value, suit, hidden }) => {
  const getColor = () => {
    if (suit === "♦" || suit === "♥") {
      return styles.red;
    }
    return styles.black;
  };

  const getCard = () => {
    return hidden ? (
      <div className={styles.hiddenCard}> </div>
    ) : (
      <div className={styles.card}>
        <div className={getColor()}>
          <h1 className={styles.value}> {value}</h1>
          <h1 className={styles.suit}> {suit}</h1>
        </div>
      </div>
    );
  };

  return <>{getCard()}</>;
};

export default Card;
