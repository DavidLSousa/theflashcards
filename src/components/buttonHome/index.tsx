import { TouchableOpacity, Text } from "react-native";
import { Href, router } from "expo-router";

import { styles } from "./styles";

type Props = {
  title: string,
  page: Href,
}

export default function Index({ title, page }: Props) {

  function handleNavigate() {
    router.navigate(page);
  }
  
  return (
    <TouchableOpacity 
      style={styles.button}
      onPress={handleNavigate}
      >


      <Text style={styles.buttonText}>{ title }</Text>

    </TouchableOpacity>
  );
}