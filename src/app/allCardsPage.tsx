import { LinearGradient } from "expo-linear-gradient";
import { ScrollView } from "react-native";

import Header from "@/src/components/header";
import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { useCard } from "../hooks/useCard";
import { useEffect } from "react";

export default function AllCardsPage() {
  const { cards, fetchCards } = useCard();;
  
  useEffect(() => {
    fetchCards();
  }, []);

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        
        {/* Os Cards precisam ser carregados do DB -> add ao estado global do zustand e depois renderizado */}
        {/* A renderização pode ser feita com Flatlist inves de Scrollview */}

        {cards.map((card, index) => (
        <Card
          key={index}
          id={card.id}
        />
      ))}
        
      </ScrollView>
    </LinearGradient>
  );
}