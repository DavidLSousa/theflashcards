import { TouchableOpacity, Text, View } from "react-native";
import { Href, router } from "expo-router";

import { styles } from "./styles";

type Props = {
  title: string,
  page: Href,
}

export default function NavegationBtn({ title, page }: Props) {

  function handleNavigate() {
    router.navigate(page);
  }

  return (
    <View style={styles.container}>
      <TouchableOpacity
        style={styles.button}
        onPress={handleNavigate}
      >


        <Text style={styles.buttonText}>{title}</Text>

      </TouchableOpacity>
    </View>
  );
}