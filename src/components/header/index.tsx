import { View, Text } from "react-native";
import { styles } from "./styles";
export	default function Header() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>The Flash Cards</Text>
      <Text style={styles.subtitle}>Seu app de cartões de revisão</Text>
    </View>
  );
}