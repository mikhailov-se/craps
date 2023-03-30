helm install vault hashicorp/vault --namespace vault --version 0.23.0 -f override-values.yml --dry-run


https://habr.com/ru/company/nixys/blog/545188/

``` bash
kubectl exec -ti vault-0 /bin/sh

vi /home/vault/app-policy.hcl

cat < /home/vault/app-policy.hcl
path "secret*" {
capabilities = ["read"]
}
EOF

vault policy write app /home/vault/app-policy.hcl

vault auth enable kubernetes

vault write auth/kubernetes/config \
token_reviewer_jwt="$(cat /var/run/secrets/kubernetes.io/serviceaccount/token)" \
kubernetes_host=https://${KUBERNETES_PORT_443_TCP_ADDR}:443 \
kubernetes_ca_cert=@/var/run/secrets/kubernetes.io/serviceaccount/ca.crt

vault write auth/kubernetes/role/myapp \
bound_service_account_names=app \
bound_service_account_namespaces=demo \
policies=app \
ttl=1h

vault secrets enable -path=kv kv
vault secrets enable -path=secret kv

vault kv put secret/helloworld username=foobaruser password=foobarbazpass

```

vault secrets enable database
vault write database/config/vault  plugin_name=postgresql-database-plugin   allowed_roles="my-role"  connection_url="postgresql://{{username}}:{{password}}@100.65.197.40:5432/vault?sslmode=disable" username="postgres"



