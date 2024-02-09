import AsyncStorage from '@react-native-async-storage/async-storage';

// Storage import
import { AUTH_TOKEN_STORAGE } from '@storage/storageConfig';

type StorageAuthTokenProps = {
  token: string;
  refresh_token: string;
};

export async function storageAuthTokenSave({
  token,
  refresh_token,
}: StorageAuthTokenProps) {
  await AsyncStorage.setItem(
    AUTH_TOKEN_STORAGE,
    JSON.stringify({ token, refresh_token }),
  );
}

export async function storageAuthTokenGet() {
  const response = await AsyncStorage.getItem(AUTH_TOKEN_STORAGE);

  const { token, refresh_token }: StorageAuthTokenProps = response
    ? JSON.parse(response)
    : ({} as StorageAuthTokenProps);

  return { token, refresh_token };
}
