import { View, Text, StyleSheet, Button } from "react-native";
import { LinearGradient } from "expo-linear-gradient";

import Header from "@/src/components/header";
import { colors } from "../constants/colors";
import ButtonHome from "@/src/components/buttonHome";

export default function Index() {
  return (
    <LinearGradient 
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />
      

      <View style={  styles.buttonsContainer }>
        <ButtonHome title="Criar Flash Card" />
        <ButtonHome title="Todos Flash Cards" />
        <ButtonHome title="Crie seu Simulado" />
        <ButtonHome title="Traga seus cards" />
        <ButtonHome title="Traga seus cards" />
      </View>
    
    </LinearGradient>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.whiteIce,
  },
  button: {
    backgroundColor: colors.whiteIce,
  },
  buttonsContainer: {
    flex: 1,
    justifyContent: "center",
  }
})