import { LinearGradient } from "expo-linear-gradient";
import { ScrollView, StatusBar } from "react-native";

import Header from "@/src/components/header";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

export default function SimulatedPage() {
  return (
    <LinearGradient 
          colors={[colors.blueLazuli, colors.blueMedium]}
          style={styles.container}
        >
          <StatusBar hidden={true} />
          
          <Header />
          
          <ScrollView contentContainerStyle={styles.scrollContent}>
            {/* Carrega os cards do simulado */}
            {/* <Card /> */}
          </ScrollView>
    </LinearGradient>
  );
}