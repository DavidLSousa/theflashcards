import { View } from "react-native";
import { LinearGradient } from "expo-linear-gradient";

import Header from "@/src/components/header";
import ButtonHome from "@/src/components/buttonHome";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

export default function Index() {
  return (
    <LinearGradient 
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />
      
      <View style={  styles.buttonsContainer }>
        <ButtonHome title="Criar Flash Card" page="/newCardPage" />
        <ButtonHome title="Todos Flash Cards" page="/allCardsPage" />
        <ButtonHome title="Crie seu Simulado" page="/simulatedPage" />
        <ButtonHome title="Traga seus cards" page="/importCardsPage" />
      </View>
    
    </LinearGradient>
  );
}
