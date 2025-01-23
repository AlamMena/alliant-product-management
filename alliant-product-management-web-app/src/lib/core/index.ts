export function formatCurrency(value: number) {
  return new Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "USD",
  }).format(value);
}
export function HandleDownloadTxt<T>(title: string, data: T[]) {
  try {
    console.log("he");
    // Convert each object in the array to a JSON string, then join them with newlines
    const text = data.map((item) => JSON.stringify(item, null, 2)).join("\n\n");
    const blob = new Blob([text], { type: "text/plain" });
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = url;
    a.download = `${title}-${new Date().getTime()}.txt`; // Set the file name

    a.click();

    URL.revokeObjectURL(url);
  } catch (error) {
    console.log(error);
  }
}
