import { TouchableOpacity, Text } from "react-native";
import { styles } from "./styles";

type Props = {
  title: string
}

export default function Index({ title }: Props) {
  return (
    <TouchableOpacity 
      style={styles.button} 
      onPress={() => console.log(title)}>

      <Text style={styles.buttonText}>{ title }</Text>

    </TouchableOpacity>
  );
}